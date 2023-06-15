"use client";

import Link from "next/link";
import { User } from "next-auth";
import { signOut } from "next-auth/react";

import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu";
import { UserAvatar } from "@/components/user-avatar";

interface UserAccountNavProps extends React.HTMLAttributes<HTMLDivElement> {
  user: Pick<User, "name" | "image" | "email">;
  type: "ADMIN" | "DASHBOARD";
}

export function UserAccountNav({ user, type }: UserAccountNavProps) {
  return (
    <DropdownMenu>
      <DropdownMenuTrigger>
        <UserAvatar
          name={user.name || undefined}
          image={user.image || undefined}
          className="h-8 w-8"
        />
      </DropdownMenuTrigger>
      <DropdownMenuContent align="end">
        <div className="flex items-center justify-start gap-2 p-2">
          <div className="flex flex-col space-y-1 leading-none">
            {user.name && <p className="font-medium">{user.name}</p>}
            {user.email && (
              <p className="w-[200px] truncate text-sm text-muted-foreground">
                {user.email}
              </p>
            )}
          </div>
        </div>
        <DropdownMenuSeparator />
        {type === "DASHBOARD" && (
          <>
            <DropdownMenuItem asChild>
              <Link href="/dashboard">Dashboard</Link>
            </DropdownMenuItem>
          </>
        )}
        {type === "ADMIN" && (
          <>
            {" "}
            <DropdownMenuItem asChild>
              <Link href="/admin/billing-types">Billing Types</Link>
            </DropdownMenuItem>
            <DropdownMenuItem asChild>
              <Link href="/admin/clients">Clients</Link>
            </DropdownMenuItem>
            <DropdownMenuItem asChild>
              <Link href="/admin/projects">Projects</Link>
            </DropdownMenuItem>
          </>
        )}
        <DropdownMenuSeparator />
        <DropdownMenuItem asChild>
          <Link href="/dashboard/settings">Settings</Link>
        </DropdownMenuItem>
        <DropdownMenuItem
          className="cursor-pointer"
          onSelect={(event) => {
            event.preventDefault();
            signOut({
              callbackUrl: `${window.location.origin}/login`,
            });
          }}
        >
          Sign out
        </DropdownMenuItem>
      </DropdownMenuContent>
    </DropdownMenu>
  );
}
