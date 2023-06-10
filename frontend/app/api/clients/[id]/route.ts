import { getServerSession } from "next-auth";
import * as z from "zod";

import { ApiClient } from "@/lib/client";
import { authOptions } from "@/lib/auth";
import { resourceNameClient } from "../route";

const routeContextSchema = z.object({
  params: z.object({
    id: z.string(),
  }),
});

export async function DELETE(
  req: Request,
  context: z.infer<typeof routeContextSchema>
) {
  try {
    const session = await getServerSession(authOptions);

    if (!session) {
      return new Response("Unauthorized", { status: 403 });
    }
    // Validate the route params.
    const { params } = routeContextSchema.parse(context);

    await ApiClient.DELETE(resourceNameClient, params.id);

    return new Response(null, { status: 204 });
  } catch (error) {
    if (error instanceof z.ZodError) {
      return new Response(JSON.stringify(error.issues), { status: 422 });
    }

    return new Response(null, { status: 500 });
  }
}
