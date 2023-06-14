import { redirect } from "next/navigation";

import { authOptions } from "@/lib/auth";
import { getCurrentUser } from "@/lib/session";
import { DashboardHeader } from "@/components/header";
import { DashboardShell } from "@/components/shell";

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
