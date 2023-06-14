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

export default async function AdminPage() {
  const user = await getCurrentUser();

  if (!user) {
    redirect(authOptions?.pages?.signIn || "/login");
  }

  return (
    <DashboardShell>
      <DashboardHeader
        heading="Admin"
        text="Internal use."
      ></DashboardHeader>
      <div></div>
    </DashboardShell>
  );
}
