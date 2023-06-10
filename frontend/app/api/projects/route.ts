import { getServerSession } from "next-auth/next";
import * as z from "zod";

import { authOptions } from "@/lib/auth";
import { postProject, updateProject } from "@/lib/client";
import { ProjectSchema } from "@/schema";

const postCreateProject = ProjectSchema;

export async function POST(req: Request) {
  try {
    const session = await getServerSession(authOptions);

    if (!session) {
      return new Response("Unauthorized", { status: 403 });
    }
    const json = await req.json();
    if (json.startDate) {
      json.startDate = new Date(json.startDate);
    }
    if (json.endDate) {
      json.endDate = new Date(json.endDate);
    }
    const body = postCreateProject.parse(json);

    const project = await postProject(body);

    return new Response(JSON.stringify(project));
  } catch (error) {
    if (error instanceof z.ZodError) {
      return new Response(JSON.stringify(error.issues), { status: 422 });
    }
    return new Response(null, { status: 500 });
  }
}

export async function PUT(req: Request) {
  try {
    const session = await getServerSession(authOptions);

    if (!session) {
      return new Response("Unauthorized", { status: 403 });
    }
    const json = await req.json();
    if (json.startDate) {
      json.startDate = new Date(json.startDate);
    }
    if (json.endDate) {
      json.endDate = new Date(json.endDate);
    }
    const body = postCreateProject.parse(json);

    const project = await updateProject(body);

    return new Response(JSON.stringify(project));
  } catch (error) {
    if (error instanceof z.ZodError) {
      return new Response(JSON.stringify(error.issues), { status: 422 });
    }
    return new Response(null, { status: 500 });
  }
}

export async function DELETE(req: Request) {
  try {
    const session = await getServerSession(authOptions);

    if (!session) {
      return new Response("Unauthorized", { status: 403 });
    }
    const json = await req.json();
    if (json.startDate) {
      json.startDate = new Date(json.startDate);
    }
    if (json.endDate) {
      json.endDate = new Date(json.endDate);
    }
    const body = postCreateProject.parse(json);

    const project = await updateProject(body);

    return new Response(JSON.stringify(project));
  } catch (error) {
    if (error instanceof z.ZodError) {
      return new Response(JSON.stringify(error.issues), { status: 422 });
    }
    return new Response(null, { status: 500 });
  }
}
