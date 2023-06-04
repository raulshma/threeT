import { getServerSession } from "next-auth/next";

import { authOptions } from "@/lib/auth";
import { getToken } from "next-auth/jwt";

export async function getCurrentUser() {
  const session = await getServerSession(authOptions);

  return session?.user;
}

export async function getAccessToken() {
  const session = await getServerSession(authOptions);

  return session?.accessToken;
}
