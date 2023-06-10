import { redirect } from "next/navigation";

import { authOptions } from "@/lib/auth";
import { getAccessToken, getCurrentUser } from "@/lib/session";
import { EmptyPlaceholder } from "@/components/empty-placeholder";
import { DashboardHeader } from "@/components/header";
import { CardItem } from "@/components/card";
import { DashboardShell } from "@/components/shell";
import { getResouceUrl } from "@/lib/utils";
import { BillingType } from "@/types";

export const metadata = {
  title: "Dashboard",
};

export const getBillingTypes = async () => {
  var token = await getAccessToken();
  var response = await fetch(`${getResouceUrl()}api/billingtype`, {
    headers: {
      "Content-Type": "application/json",
      Authorization: "Bearer " + token,
    },
  });
  if (response.ok) {
    var items = await response.json();
    return items as BillingType[];
  }
};

export default async function DashboardPage() {
  const user = await getCurrentUser();

  if (!user) {
    redirect(authOptions?.pages?.signIn || "/login");
  }

  const items = await getBillingTypes();

  return (
    <DashboardShell>
      <DashboardHeader
        heading="ThreeT"
        text="Manage your work."
      ></DashboardHeader>
      <div>
        {items?.length ? (
          <div className="divide-y divide-border rounded-md border">
            {items.map((item: any, i: number) => (
              <CardItem
                key={item.id}
                title={item.name}
                id={String(item.id)}
                createdAt={new Date()}
              />
            ))}
          </div>
        ) : (
          <EmptyPlaceholder>
            <EmptyPlaceholder.Icon name="post" />
            <EmptyPlaceholder.Title>No posts created</EmptyPlaceholder.Title>
            <EmptyPlaceholder.Description>
              You don&apos;t have any posts yet. Start creating content.
            </EmptyPlaceholder.Description>
            {/* <PostCreateButton variant="outline" /> */}
          </EmptyPlaceholder>
        )}
      </div>
    </DashboardShell>
  );
}
