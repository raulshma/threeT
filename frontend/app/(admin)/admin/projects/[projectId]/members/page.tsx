import { redirect } from "next/navigation";

import { authOptions } from "@/lib/auth";
import { getCurrentUser } from "@/lib/session";
import { DashboardHeader } from "@/components/header";
import { DashboardShell } from "@/components/shell";
import {
  getClients,
  getProject,
  getBillingTypes,
  ApiClient,
} from "@/lib/client";
import { ProjectForm } from "@/components/project-form";
import { CreateButton } from "@/components/create-button";
import Link from "next/link";
import { cn } from "@/lib/utils";
import { buttonVariants } from "@/components/ui/button";
import { Icons } from "@/components/icons";

export const resourceNameProjectMembers = "projectUser";

export const metadata = {
  title: "Project members",
  description: "Manage project members.",
  relativePath: "/admin/projects",
};

export type ProjectMembersPagePageParams = {
  params: { projectId: string };
};

export default async function ProjectMembersPage({
  params: { projectId },
}: ProjectMembersPagePageParams) {
  console.log(projectId);
  const user = await getCurrentUser();
  if (!user) {
    redirect(authOptions?.pages?.signIn || "/login");
  }
  if (!projectId) {
    redirect(metadata.relativePath);
  }

  const project = await getProject(projectId);
  const members = (await ApiClient.GET(
    resourceNameProjectMembers,
    projectId
  )) as any;

  return (
    <DashboardShell>
      <DashboardHeader
        heading={`${project.name} ${metadata.title}`}
        text={`Add, update & remove members from or to project.`}
      >
        <Link
          href={metadata.relativePath}
          className={cn(buttonVariants({ variant: "ghost" }))}
        >
          <>
            <Icons.chevronLeft className="mr-2 h-4 w-4" />
            Back
          </>
        </Link>
      </DashboardHeader>
      <div className="grid gap-8">
        {members &&
          members.length > 0 &&
          members.map((member: any) => (
            <>
              <div>{member.email}</div>
            </>
          ))}
      </div>
    </DashboardShell>
  );
}
