import { User } from "next-auth";
import { JWT } from "next-auth/jwt";

type UserId = string;

declare module "next-auth/jwt" {
  interface JWT {
    id: UserId;
  }
}

declare module "next-auth" {
  interface Session {
    accessToken: string,
    userId: string | undefined,
    user: User & {
      id: UserId;
    };
  }
}
