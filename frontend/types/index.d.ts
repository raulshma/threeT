import { User } from "@prisma/client";
import type { Icon } from "lucide-react";

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

export type Client = {
  name: string;
  boardedOn?: Date;
  boardedById?: string;
  country?: string;
  isActive?: boolean;
  billingTypeId?: string;
  id: string;
  createdAt?: Date;
  updatedAt?: Date;
  lastTouchedBy?: string;
};

export type BillingType = {
  id: string;
  name: string;
};

export type Project = {
  name: string;
  startDate: Date;
  endDate?: Date;
  billingPrice: number;
  clientId: string;
};
