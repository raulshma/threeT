import { redirect } from "next/navigation";

import { authOptions } from "@/lib/auth";
import { getCurrentUser } from "@/lib/session";
import { DashboardHeader } from "@/components/header";
import { DashboardShell } from "@/components/shell";
import { CreateButton } from "@/components/create-button";
import { ClientForm } from "@/components/client-form";
import { getBillingTypes } from "@/lib/client";

export const metadata = {
  title: "Onboard Client",
  description: "Onboard a client.",
  relativePath: "/admin/clients",
};

export default async function ClientsCreatePage() {
  const user = await getCurrentUser();
  if (!user) {
    redirect(authOptions?.pages?.signIn || "/login");
  }

  const result = await getBillingTypes();
  const billingTypes = result.items;

  return (
    <DashboardShell>
      <DashboardHeader heading={metadata.title} text={metadata.description}>
        <CreateButton
          title={metadata.title}
          goto={`${metadata.relativePath}/create`}
        />
      </DashboardHeader>
      <div className="grid gap-8">
        <ClientForm
          billingTypes={billingTypes}
          listPage={metadata.relativePath}
        />
      </div>
    </DashboardShell>
  );
}
