import { CardItem } from "@/components/card";
import { DashboardHeader } from "@/components/header";
import { DashboardShell } from "@/components/shell";

export default function AdminLoading() {
  return (
    <DashboardShell>
      <DashboardHeader
        heading="Admin"
        text="Internal use."
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
