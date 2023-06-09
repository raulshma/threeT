import { redirect } from "next/navigation";

import { authOptions } from "@/lib/auth";
import { getCurrentUser } from "@/lib/session";
import { DashboardHeader } from "@/components/header";
import { DashboardShell } from "@/components/shell";
import { CreateButton } from "@/components/create-button";

export const metadata = {
  title: "Create Billing Type",
  description: "Create a new billing type.",
  relativePath: "/admin/billing-types",
};

export default async function BillingTypesCreatePage() {
  const user = await getCurrentUser();
  if (!user) {
    redirect(authOptions?.pages?.signIn || "/login");
  }

  return (
    <DashboardShell>
      <DashboardHeader
        heading={metadata.title}
        text={metadata.description}
      >
        <CreateButton title={"billing type"} goto={`${metadata.relativePath}/create`} />
      </DashboardHeader>
      <div className="grid gap-8">
      </div>
    </DashboardShell>
  );
}
