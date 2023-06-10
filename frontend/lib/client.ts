import { BillingType, Client, Project } from "@/types";
import { getAccessToken } from "./session";
import { getResouceUrl } from "./utils";

const Get = async <T>(path: string, id: string = ""): Promise<T> => {
  var token = await getAccessToken();
  var response = await fetch(
    `${getResouceUrl()}api/${path}${id ? "/" + id : ""}`,
    {
      headers: {
        "Content-Type": "application/json",
        Authorization: "Bearer " + token,
      },
    }
  );
  if (response.ok) {
    var items = await response.json();
    return items satisfies T;
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

const Put = async <T>(path: string, body: T): Promise<T> => {
  var token = await getAccessToken();
  var response = await fetch(`${getResouceUrl()}api/${path}`, {
    method: "PUT",
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

const Delete = async (path: string, id: string) => {
  var token = await getAccessToken();
  var response = await fetch(`${getResouceUrl()}api/${path}/${id}`, {
    method: "DELETE",
    headers: {
      "Content-Type": "application/json",
      Authorization: "Bearer " + token,
    },
  });
  if (response.ok) {
    return;
  }
  throw new Error(response.status.toString());
};

export const getBillingTypes = async () =>
  await Get<BillingType[]>("billingtype");

export const getProjects = async () => await Get<Project[]>("project");
export const getProject = async (id: string) =>
  await Get<Project>("project", id);
export const postProject = async (body: Project) =>
  await Post<Project>("project", body);
export const updateProject = async (body: Project) =>
  await Put<Project>("project", body);
export const deleteProject = async (id: string) => await Delete("project", id);

export const getClients = async () => await Get<Client[]>("client");
export const postClient = async (body: Client) =>
  await Post<Client>("project", body);
export const updateClient = async (body: Project) =>
  await Put<Project>("project", body);
export const deleteClient = async (id: string) => await Delete("project", id);

// Generic crud
export const ApiClient = {
  LIST: async <T>(resourceName: string): Promise<T> => await Get<T>(resourceName),
  GET: async <T>(resourceName: string, id: string): Promise<T> =>
    await Get<T>(resourceName, id),
  POST: async <T>(resourceName: string, body: T): Promise<T> =>
    await Post<T>(resourceName, body),
  PUT: async <T>(resourceName: string, body: T): Promise<T> =>
    await Put<T>(resourceName, body),
  DELETE: async (resourceName: string, id: string): Promise<void> =>
    await Delete(resourceName, id),
};
