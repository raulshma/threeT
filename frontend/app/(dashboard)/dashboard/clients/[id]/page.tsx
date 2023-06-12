import { redirect } from "next/navigation";

import { authOptions } from "@/lib/auth";
import { getCurrentUser } from "@/lib/session";
import { DashboardHeader } from "@/components/header";
import { DashboardShell } from "@/components/shell";
import { ApiClient, getClients } from "@/lib/client";
import { ProjectForm } from "@/components/project-form";
import { CreateButton } from "@/components/create-button";
import { getBillingTypes } from "../../page";
import { ClientForm } from "@/components/client-form";
import { resourceNameClient } from "@/app/api/clients/route";
import { Client } from "@/types";

export const metadata = {
  title: "Onboard Client",
  description: "Onboard a client.",
  relativePath: "/dashboard/clients",
};

export type ClientEditPageParams = {
  params: { id: string };
};

export default async function ClientsEditPage({
  params: { id },
}: ClientEditPageParams) {
  const user = await getCurrentUser();
  if (!user) {
    redirect(authOptions?.pages?.signIn || "/login");
  }
  if (!id) {
    redirect("/dashboard/clients");
  }
  const [billingTypes, client] = await Promise.all([
    getBillingTypes(),
    ApiClient.GET<Client>(resourceNameClient, id),
  ]);

  return (
    <DashboardShell>
      <DashboardHeader heading={metadata.title} text={metadata.description}>
        <CreateButton
          title={metadata.title}
          goto={`${metadata.relativePath}/create`}
        />
      </DashboardHeader>
      <div className="grid gap-8">
        <ClientForm client={client} billingTypes={billingTypes} />
      </div>
    </DashboardShell>
  );
}
