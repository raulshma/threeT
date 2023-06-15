import { redirect } from "next/navigation";

import { authOptions } from "@/lib/auth";
import { getCurrentUser } from "@/lib/session";
import { DashboardHeader } from "@/components/header";
import { DashboardShell } from "@/components/shell";
import {
  getProject,
  ApiClient,
  resourceNameProjectMembers,
  resourceNameMembers,
} from "@/lib/client";
import Link from "next/link";
import { cn } from "@/lib/utils";
import { Button, buttonVariants } from "@/components/ui/button";
import { Icons } from "@/components/icons";
import { Member, ProjectUser } from "@/types";
import {
  HoverCard,
  HoverCardContent,
  HoverCardTrigger,
} from "@/components/ui/hover-card";
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import { CalendarDays } from "lucide-react";
import { ProjectMembersComboBox } from "@/components/project-members-combobox";

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
  const user = await getCurrentUser();
  if (!user) {
    redirect(authOptions?.pages?.signIn || "/login");
  }
  if (!projectId) {
    redirect(metadata.relativePath);
  }

  const project = await getProject(projectId);
  const peojectMembers = await ApiClient.GET<ProjectUser[]>(
    resourceNameProjectMembers,
    projectId
  );
  const allMembers = await ApiClient.GET<Member[]>(resourceNameMembers);
  return (
    <DashboardShell>
      <DashboardHeader
        heading={`${project.name} ${metadata.title} - (${peojectMembers.length})`}
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
      {/* <div className="grid gap-8">
        {members &&
          members.length > 0 &&
          members.map((member) => (
            <Card key={`${member.projectId}-${member.userId}`}>
              <CardHeader>
                <CardTitle>{member.userEmail} </CardTitle>
                <CardDescription>{member.userDesignationName}</CardDescription>
              </CardHeader>
            </Card>
          ))}
      </div> */}
      <div className="grid gap-1 justify-start px-2">
        <ProjectMembersComboBox
          items={allMembers}
          existingMembers={peojectMembers}
        />
      </div>
      <div className="grid gap-1 justify-start">
        {peojectMembers &&
          peojectMembers.length > 0 &&
          peojectMembers.map((member, index) => {
            const joiningDate = new Date(member.userJoiningDate);
            return (
              <HoverCard key={`${member.projectId}-${member.userId}`}>
                <HoverCardTrigger asChild>
                  <Button variant="link">
                    {index + 1}. {member.userEmail}
                  </Button>
                </HoverCardTrigger>
                <HoverCardContent className="w-auto">
                  <div className="flex justify-between space-x-4">
                    <Avatar>
                      <AvatarImage src="https://github.com/vercel.png" />
                      <AvatarFallback>VC</AvatarFallback>
                    </Avatar>
                    <div className="space-y-1">
                      <h4 className="text-sm font-semibold">
                        {member.userName}
                      </h4>
                      <code className="relative rounded bg-muted px-[0.3rem] py-[0.2rem] font-mono text-sm font-semibold">
                        {member.userDesignationName}
                      </code>
                      <div className="flex items-center pt-2">
                        <CalendarDays className="mr-2 h-4 w-4 opacity-70" />{" "}
                        <span className="text-xs text-muted-foreground">
                          Joined {joiningDate.toDateString()}
                        </span>
                      </div>
                    </div>
                  </div>
                </HoverCardContent>
              </HoverCard>
            );
          })}
      </div>
    </DashboardShell>
  );
}
