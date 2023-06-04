import { CardItem } from "@/components/card";
import { DashboardHeader } from "@/components/header";
import { DashboardShell } from "@/components/shell";

export default function DashboardLoading() {
  return (
    <DashboardShell>
      <DashboardHeader
        heading="Dashboard"
        text="Manage your daily work."
      ></DashboardHeader>
      <div className="divide-border-200 divide-y rounded-md border">
        <CardItem.Skeleton />
        <CardItem.Skeleton />
        <CardItem.Skeleton />
        <CardItem.Skeleton />
        <CardItem.Skeleton />
      </div>
    </DashboardShell>
  );
}
