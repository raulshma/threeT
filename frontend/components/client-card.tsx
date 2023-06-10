import Link from "next/link";

import { Skeleton } from "@/components/ui/skeleton";
import { cn, formatDate } from "@/lib/utils";
import { CardOperations } from "./card-operations";

interface ClientCardItemProps {
  id: string;
  title: string;
  createdAt: Date;
  isActive: boolean;
  isFor?: string;
}

export function ClientCardItem({
  id,
  isActive,
  isFor = "clients",
  title,
  createdAt,
}: ClientCardItemProps) {
  const linkUrl = isFor
    ? isFor.startsWith("/")
      ? isFor.substring(1)
      : isFor
    : "";
  return (
    <div
      className={cn(
        "flex items-center justify-between p-4 border-2 rounded-sm",
        isActive ? "border-l-cyan-400" : "border-l-red-400"
      )}
    >
      <div className="grid gap-1">
        <Link
          href={`/${linkUrl}/${id}`}
          className="font-semibold hover:underline"
        >
          {title}
        </Link>
        <div>
          <p className="text-sm text-muted-foreground">
            {formatDate(createdAt?.toDateString())}
          </p>
        </div>
      </div>
      <CardOperations
        id={id}
        itemType="clients"
        itemName="client"
        editPath="dashboard/clients"
      />
    </div>
  );
}

ClientCardItem.Skeleton = function CardItemSkeleton() {
  return (
    <div className="p-4">
      <div className="space-y-3">
        <Skeleton className="h-5 w-2/5" />
        <Skeleton className="h-4 w-4/5" />
      </div>
    </div>
  );
};
