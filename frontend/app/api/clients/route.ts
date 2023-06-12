import { getServerSession } from "next-auth/next";
import * as z from "zod";

import { authOptions } from "@/lib/auth";
import { ApiClient } from "@/lib/client";
import { ClientFormSchema } from "@/schema";

export const resourceNameClient = "client";

export async function POST(req: Request) {
  try {
    const session = await getServerSession(authOptions);

    if (!session) {
      return new Response("Unauthorized", { status: 403 });
    }
    const json = await req.json();
    if (json.boardedOn) {
      json.boardedOn = new Date(json.boardedOn);
    }
    if (session.userId) json.boardedById = session.userId;
    // json.updatedAt = new Date();
    const body = ClientFormSchema.parse(json);

    const result = await ApiClient.POST(resourceNameClient, body);

    return new Response(JSON.stringify(result));
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
      json.boardedOn = new Date(json.boardedOn);
    }
    json.updatedAt = new Date();

    const body = ClientFormSchema.parse(json);

    const result = await ApiClient.PUT(resourceNameClient, body);

    return new Response(JSON.stringify(result));
  } catch (error) {
    if (error instanceof z.ZodError) {
      return new Response(JSON.stringify(error.issues), { status: 422 });
    }
    return new Response(null, { status: 500 });
  }
}
