import { User } from "@prisma/client";
import * as z from "zod";
import type { Icon } from "lucide-react";
import { ProjectSchema, ClientFormSchema } from "@/schema";
import { Icons } from "@/components/icons";

export type NavItem = {
  title: string;
  href: string;
  disabled?: boolean;
};

export type MainNavItem = NavItem;

export type SidebarNavItem = {
  title: string;
  disabled?: boolean;
  external?: boolean;
  icon?: keyof typeof Icons;
} & (
  | {
      href: string;
      items?: never;
    }
  | {
      href?: string;
      items: NavLink[];
    }
);

export type SiteConfig = {
  name: string;
  description: string;
  url: string;
  ogImage: string;
  links: {
    twitter: string;
    github: string;
  };
};

export type DocsConfig = {
  mainNav: MainNavItem[];
  sidebarNav: SidebarNavItem[];
};

export type MarketingConfig = {
  mainNav: MainNavItem[];
};

export type DashboardConfig = {
  mainNav: MainNavItem[];
  sidebarNav: SidebarNavItem[];
};

export type AdminConfig = {
  mainNav: MainNavItem[];
  sidebarNav: SidebarNavItem[];
};

export type BillingType = {
  id: string;
  name: string;
};
export type Client = z.infer<typeof ClientFormSchema>;
export type Project = z.infer<typeof ProjectSchema>;

export type AdditionalDropdownItems = [
  { name: "PROJECT_TEAM_MEMBERS"; route: "/members" }
];
