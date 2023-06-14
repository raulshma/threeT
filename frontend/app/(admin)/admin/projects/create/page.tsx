import { redirect } from "next/navigation";

import { authOptions } from "@/lib/auth";
import { getCurrentUser } from "@/lib/session";
import { DashboardHeader } from "@/components/header";
import { DashboardShell } from "@/components/shell";
import { getBillingTypes, getClients } from "@/lib/client";
import { ProjectForm } from "@/components/project-form";
import { CreateButton } from "@/components/create-button";

export const metadata = {
  title: "Create Project",
  description: "Create a new project.",
  relativePath: "/admin/projects",
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
        <CreateButton
          title="project"
          goto={`${metadata.relativePath}/create`}
        />
      </DashboardHeader>
      <div className="grid gap-8">
        <ProjectForm
          clients={clients}
          billingTypes={billingTypes}
          listPage={metadata.relativePath}
        />
      </div>
    </DashboardShell>
  );
}
