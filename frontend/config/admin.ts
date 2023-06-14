import { AdminConfig } from "@/types";

export const adminConfig: AdminConfig = {
    mainNav: [
      {
        title: "Dashboard",
        href: "/dashboard",
      },
      {
        title: "Admin",
        href: "/admin",
      },
    ],
    sidebarNav: [
      {
        title: "Analytics",
        href: "/admin",
        icon: "post",
      },
      {
        title: "Billing Types",
        href: "/admin/billing-types",
        icon: "billing",
      },
      {
        title: "Clients",
        href: "/admin/clients",
        icon: "client",
      },
      {
        title: "Projects",
        href: "/admin/projects",
        icon: "billing",
      },
    ],
  };
  