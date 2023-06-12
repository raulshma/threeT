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
import { getBillingTypes, getProjects } from "@/lib/client";
import { CardItem } from "@/components/card";
import { EmptyPlaceholder } from "@/components/empty-placeholder";
import { ProjectForm } from "@/components/project-form";
import { CreateButton } from "@/components/create-button";

export const metadata = {
  title: "Billing Types",
  description: "Manage billing types.",
  relativePath: "/dashboard/billing-types",
};

export default async function BillingTypesPage() {
  const user = await getCurrentUser();

  if (!user) {
    redirect(authOptions?.pages?.signIn || "/login");
  }

  const items = await getBillingTypes();

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
                <CardItem
                  key={item.id}
                  title={item.name}
                  id={String(item.id)}
                  createdAt={new Date()}
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
