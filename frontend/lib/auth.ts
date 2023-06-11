import { NextAuthOptions } from "next-auth";

export const authOptions: NextAuthOptions = {
  session: {
    strategy: "jwt",
  },
  pages: {
    signIn: "/login",
  },
  jwt: {
    secret: process.env.SECRET,
  },
  secret: process.env.SECRET,
  providers: [
    {
      id: "threet",
      name: "threet",
      type: "oauth",
      issuer: process.env.AUTH_SERVER,
      client: {
        token_endpoint_auth_method: "none",
      },
      wellKnown: `${process.env.AUTH_SERVER}.well-known/openid-configuration`,
      authorization: {
        params: {
          scope: "openid profile email offline_access",
        },
      },
      httpOptions: {
        timeout: 15000,
      },
      clientId: "threet-app",
      profile(profile) {
        return {
          id: profile.sub,
          name: profile.name,
          email: profile.email,
          image: profile.picture,
        };
      },
    },
  ],
  callbacks: {
    async signIn() {
      return true;
    },
    async session({ session, token }) {
      session.accessToken = token.accessToken as string;
      session.userId = token.sub;
      return session;
    },
    async jwt({ token, account }) {
      if (account) {
        token.accessToken = account.access_token!;
        if (account.userId) token.userId = account.userId;
      }
      return token;
    },
  },
  events: {},
  // Enable debug messages in the console if you are having problems
  debug: true,
};
