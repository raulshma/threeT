import { BillingType, Client, Project } from "@/types";
import { getAccessToken } from "./session";
import { getResouceUrl } from "./utils";

const Get = async <T>(path: string): Promise<T[]> => {
  var token = await getAccessToken();
  var response = await fetch(`${getResouceUrl()}api/${path}`, {
    headers: {
      "Content-Type": "application/json",
      Authorization: "Bearer " + token,
    },
  });
  if (response.ok) {
    var items = await response.json();
    return items satisfies T[];
  }
  throw new Error(response.status.toString());
};

const Post = async <T>(path: string, body: T): Promise<T> => {
  var token = await getAccessToken();
  var response = await fetch(`${getResouceUrl()}api/${path}`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Authorization: "Bearer " + token,
    },
    body: JSON.stringify(body),
  });
  if (response.ok) {
    var items = await response.json();
    return items satisfies T;
  }
  throw new Error(response.status.toString());
};

export const getBillingTypes = async () =>
  await Get<BillingType>("billingtype");

export const getProjects = async () => await Get("project");
export const getClients = async () => await Get<Client>("client");

export const postProject = async (body: Project) =>
  await Post<Project>("project", body);
