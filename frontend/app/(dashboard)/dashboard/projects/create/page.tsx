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
import { getClients, getProjects } from "@/lib/client";
import { CardItem } from "@/components/card";
import { EmptyPlaceholder } from "@/components/empty-placeholder";
import { ProjectForm } from "@/components/project-form";
import { CreateButton } from "@/components/create-button";
import { getBillingTypes } from "../../page";

export const metadata = {
  title: "Create Project",
  description: "Create a new project.",
};

export default async function ProjectPage() {
  const user = await getCurrentUser();

  if (!user) {
    redirect(authOptions?.pages?.signIn || "/login");
  }

  const clients = await getClients();
  const billingTypess = await getBillingTypes();

  return (
    <DashboardShell>
      <DashboardHeader
        heading="Projects"
        text="Manage current and past projects."
      >
        <CreateButton title="project" goto="/dashboard/projects/create" />
      </DashboardHeader>
      <div className="grid gap-8">
        <ProjectForm clients={clients} billingTypes={billingTypess} />
      </div>
    </DashboardShell>
  );
}
