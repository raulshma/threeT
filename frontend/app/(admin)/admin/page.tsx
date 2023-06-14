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
