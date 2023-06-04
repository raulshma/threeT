"use client";

import * as React from "react";
import { useRouter } from "next/navigation";

import { cn } from "@/lib/utils";
import { ButtonProps, buttonVariants } from "@/components/ui/button";
import { Icons } from "@/components/icons";

interface CreateButtonProps extends ButtonProps {
  title: string;
  goto: string;
}

export function CreateButton({
  className,
  variant,
  title,
  goto,
  ...props
}: CreateButtonProps) {
  const router = useRouter();
  const [isLoading, setIsLoading] = React.useState<boolean>(false);

  async function onClick() {
    // setIsLoading(true);
    // setIsLoading(false);
    // This forces a cache invalidation.
    router.push(goto);
  }

  return (
    <button
      onClick={onClick}
      className={cn(
        buttonVariants({ variant }),
        {
          "cursor-not-allowed opacity-60": isLoading,
        },
        className
      )}
      disabled={isLoading}
      {...props}
    >
      {isLoading ? (
        <Icons.spinner className="mr-2 h-4 w-4 animate-spin" />
      ) : (
        <Icons.add className="mr-2 h-4 w-4" />
      )}
      New {title}
    </button>
  );
}
