import Link from "next/link";

import { Skeleton } from "@/components/ui/skeleton";
import { formatDate } from "@/lib/utils";
import { CardOperations } from "./card-operations";

interface CardItemProps {
  id: string;
  title: string;
  createdAt: Date;
  isFor?: string;
}

export function CardItem({
  id,
  isFor = "project",
  title,
  createdAt,
}: CardItemProps) {
  const linkUrl = isFor
    ? isFor.startsWith("/")
      ? isFor.substring(1)
      : isFor
    : "";
  return (
    <div className="flex items-center justify-between p-4">
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
        itemType="projects"
        itemName="project"
        editPath={isFor}
      />
    </div>
  );
}

CardItem.Skeleton = function CardItemSkeleton() {
  return (
    <div className="p-4">
      <div className="space-y-3">
        <Skeleton className="h-5 w-2/5" />
        <Skeleton className="h-4 w-4/5" />
      </div>
    </div>
  );
};
