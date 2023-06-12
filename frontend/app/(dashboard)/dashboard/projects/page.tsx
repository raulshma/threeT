import { redirect } from "next/navigation";

import { authOptions } from "@/lib/auth";
import { getCurrentUser } from "@/lib/session";
import { Alert, AlertDescription, AlertTitle } from "@/components/ui/alert";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { DashboardHeader } from "@/components/header";
import { Icons } from "@/components/icons";
import { DashboardShell } from "@/components/shell";
import { getProjects } from "@/lib/client";
import { CardItem } from "@/components/card";
import { EmptyPlaceholder } from "@/components/empty-placeholder";
import { ProjectForm } from "@/components/project-form";
import { CreateButton } from "@/components/create-button";

export const metadata = {
  title: "Projects",
  description: "Manage current and past projects.",
};

export default async function ProjectPage() {
  const user = await getCurrentUser();

  if (!user) {
    redirect(authOptions?.pages?.signIn || "/login");
  }

  const projects = await getProjects();

  return (
    <DashboardShell>
      <DashboardHeader
        heading="Projects"
        text="Manage current and past projects."
      >
        <CreateButton title="project" goto="/dashboard/projects/create" />
      </DashboardHeader>
      <div className="grid gap-8">
        <div>
          {projects?.length ? (
            <div className="divide-y divide-border rounded-md border">
              {projects.map((item: any, i: number) => (
                <CardItem
                  key={item.id}
                  title={item.name}
                  id={String(item.id)}
                  createdAt={new Date()}
                  isFor="dashboard/projects"
                />
              ))}
            </div>
          ) : (
            <EmptyPlaceholder>
              <EmptyPlaceholder.Icon name="post" />
              <EmptyPlaceholder.Title>
                No projects created
              </EmptyPlaceholder.Title>
              <EmptyPlaceholder.Description>
                You don&apos;t have any projects yet. Start creating projects.
              </EmptyPlaceholder.Description>
              {/* <PostCreateButton variant="outline" /> */}
            </EmptyPlaceholder>
          )}
        </div>
        {/* <ProjectForm
          project={{
            ...project,
            isCanceled,
          }}
        /> */}
      </div>
    </DashboardShell>
  );
}
