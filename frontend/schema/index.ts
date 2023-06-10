import * as z from "zod";
export const ProjectSchema = z.object({
  id: z.string().optional(),
  name: z.string(),
  startDate: z.date(),
  endDate: z.date().optional(),
  billingPrice: z.number().optional(),
  clientId: z.string(),
});
