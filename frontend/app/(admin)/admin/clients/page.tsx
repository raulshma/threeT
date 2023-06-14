import { redirect } from "next/navigation";

import { authOptions } from "@/lib/auth";
import { getCurrentUser } from "@/lib/session";
import { DashboardHeader } from "@/components/header";
import { DashboardShell } from "@/components/shell";
import { getClients } from "@/lib/client";
import { EmptyPlaceholder } from "@/components/empty-placeholder";
import { CreateButton } from "@/components/create-button";
import { ClientCardItem } from "@/components/client-card";

export const metadata = {
  title: "Clients",
  description: "Manage clients.",
  relativePath: "/admin/clients",
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
