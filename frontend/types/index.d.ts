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

export type ProjectUser = {
  userName: string;
  userEmail: string;
  userDesignationName: string | null;
  userId: string;
  projectId: string;
  userJoiningDate: string;
  userExperienceYears: number;
};

export type Member = {
  experience: number;
  joiningDate: Date;
  relievingDate: null;
  designationId: string;
  designation: null;
  departmentId: string;
  department: null;
  id: string;
  userName: string;
  normalizedUserName: string;
  email: string;
  normalizedEmail: string;
  emailConfirmed: boolean;
  passwordHash: string;
  securityStamp: string;
  concurrencyStamp: string;
  phoneNumber: null;
  phoneNumberConfirmed: boolean;
  twoFactorEnabled: boolean;
  lockoutEnd: null;
  lockoutEnabled: boolean;
  accessFailedCount: number;
};

export type Client = z.infer<typeof ClientFormSchema>;
export type Project = z.infer<typeof ProjectSchema>;

export type AdditionalDropdownItems = [
  { name: "PROJECT_TEAM_MEMBERS"; route: "/members" }
];
