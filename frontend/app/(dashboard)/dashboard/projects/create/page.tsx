import { redirect } from "next/navigation";

import { authOptions } from "@/lib/auth";
import { getCurrentUser } from "@/lib/session";
import { DashboardHeader } from "@/components/header";
import { DashboardShell } from "@/components/shell";
import { getClients } from "@/lib/client";
import { ProjectForm } from "@/components/project-form";
import { CreateButton } from "@/components/create-button";
import { getBillingTypes } from "../../page";

export const metadata = {
  title: "Create Project",
  description: "Create a new project.",
};


export default async function ProjectCreatePage() {
  const user = await getCurrentUser();
  if (!user) {
    redirect(authOptions?.pages?.signIn || "/login");
  }

  const [clients, billingTypes] = await Promise.all([
    getClients(),
    getBillingTypes(),
  ]);

  return (
    <DashboardShell>
      <DashboardHeader
        heading="Projects"
        text="Manage current and past projects."
      >
        <CreateButton title="project" goto="/dashboard/projects/create" />
      </DashboardHeader>
      <div className="grid gap-8">
        <ProjectForm clients={clients} billingTypes={billingTypes} />
      </div>
    </DashboardShell>
  );
}
