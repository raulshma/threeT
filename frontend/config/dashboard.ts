import { DashboardConfig } from "@/types";

export const dashboardConfig: DashboardConfig = {
  mainNav: [
    {
      title: "Documentation",
      href: "/docs",
    },
    {
      title: "Support",
      href: "/support",
      disabled: true,
    },
  ],
  sidebarNav: [
    {
      title: "Dashboard",
      href: "/dashboard",
      icon: "post",
    },
    {
      title: "Billing Types",
      href: "/dashboard/billing-types",
      icon: "billing",
    },
    {
      title: "Clients",
      href: "/dashboard/clients",
      icon: "client",
    },
    {
      title: "Projects",
      href: "/dashboard/projects",
      icon: "billing",
    },
    {
      title: "Settings",
      href: "/dashboard/settings",
      icon: "settings",
    },
  ],
};
