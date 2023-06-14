import { redirect } from "next/navigation";

import { authOptions } from "@/lib/auth";
import { getCurrentUser } from "@/lib/session";
import { DashboardHeader } from "@/components/header";
import { DashboardShell } from "@/components/shell";
import { getClients, getProject } from "@/lib/client";
import { ProjectForm } from "@/components/project-form";
import { CreateButton } from "@/components/create-button";
import { getBillingTypes } from "../../page";
import { Project } from "@/types";

export const metadata = {
  title: "Create Project",
  description: "Create a new project.",
  relativePath: "/admin/projects",
};

export type ProjectEditPageParams = {
  params: { projectId: string };
};

export default async function ProjectEditPage({
  params: { projectId },
}: ProjectEditPageParams) {
  const user = await getCurrentUser();
  if (!user) {
    redirect(authOptions?.pages?.signIn || "/login");
  }
  if (!projectId) {
    redirect(metadata.relativePath);
  }

  const [clients, billingTypes, project] = await Promise.all([
    getClients(),
    getBillingTypes(),
    getProject(projectId),
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
          project={project}
          clients={clients}
          billingTypes={billingTypes}
          listPage={metadata.relativePath}
        />
      </div>
    </DashboardShell>
  );
}
