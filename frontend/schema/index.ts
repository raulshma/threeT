import * as z from "zod";
export const ProjectSchema = z.object({
  id: z.string().optional(),
  name: z.string(),
  startDate: z.date(),
  endDate: z.date().optional(),
  billingPrice: z.number().optional(),
  clientId: z.string(),
});

export const ClientFormSchema = z.object({
  id: z.string().optional(),
  name: z.string(),
  boardedOn: z.date(),
  boardedById: z.string().optional(),
  country: z.string().optional(),
  isActive: z.boolean(),
  billingTypeId: z.string(),
  lastTouchedBy: z.string().optional(),
  createdAt: z.date().optional(),
  updatedAt: z.date().optional(),
});
