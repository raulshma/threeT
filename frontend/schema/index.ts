import * as z from "zod";
export const ProjectSchema = z.object({
  name: z.string(),
  startDate: z.date(),
  endDate: z.date().optional(),
  billingPrice: z.number().optional(),
  clientId: z.string(),
});
