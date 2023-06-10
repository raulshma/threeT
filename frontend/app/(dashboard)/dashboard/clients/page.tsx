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
import { getBillingTypes, getClients, getProjects } from "@/lib/client";
import { CardItem } from "@/components/card";
import { EmptyPlaceholder } from "@/components/empty-placeholder";
import { ProjectForm } from "@/components/project-form";
import { CreateButton } from "@/components/create-button";
import { ClientCardItem } from "@/components/client-card";

export const metadata = {
  title: "Clients",
  description: "Manage clients.",
  relativePath: "/dashboard/clients",
};

export default async function ClientsPage() {
  const user = await getCurrentUser();

  if (!user) {
    redirect(authOptions?.pages?.signIn || "/login");
  }

  const items = await getClients();

  const titleLowered = metadata.title.toLowerCase();

  return (
    <DashboardShell>
      <DashboardHeader heading={metadata.title} text={metadata.description}>
        <CreateButton
          title={metadata.title}
          goto={`${metadata.relativePath}/create`}
        />
      </DashboardHeader>
      <div className="grid gap-8">
        <div>
          {items?.length ? (
            <div className="divide-y divide-border rounded-md border">
              {items.map((item) => (
                <ClientCardItem
                  key={item.id}
                  title={item.name}
                  id={String(item.id)}
                  createdAt={new Date()}
                  isActive={item.isActive}
                  isFor={metadata.relativePath}
                />
              ))}
            </div>
          ) : (
            <EmptyPlaceholder>
              <EmptyPlaceholder.Icon name="post" />
              <EmptyPlaceholder.Title>
                No {titleLowered} created
              </EmptyPlaceholder.Title>
              <EmptyPlaceholder.Description>
                You don&apos;t have any {titleLowered} yet. Start creating{" "}
                {titleLowered}.
              </EmptyPlaceholder.Description>
              {/* <PostCreateButton variant="outline" /> */}
            </EmptyPlaceholder>
          )}
        </div>
      </div>
    </DashboardShell>
  );
}
