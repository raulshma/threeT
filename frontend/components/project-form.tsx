"use client";

import * as React from "react";

import { BillingType, Client, Project } from "@/types";
import { cn, formatDate } from "@/lib/utils";
import { Button, buttonVariants } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { toast } from "@/components/ui/use-toast";
import { Icons } from "@/components/icons";
import * as z from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import {
  FormControl,
  FormDescription,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
  Form,
} from "./ui/form";
import { Input } from "./ui/input";
import {
  SelectValue,
  Select,
  SelectTrigger,
  SelectContent,
  SelectItem,
} from "./ui/select";
import { Popover, PopoverContent, PopoverTrigger } from "./ui/popover";
import { Calendar } from "./ui/calendar";
import { CalendarIcon } from "lucide-react";
import { format } from "date-fns";
import { postProject } from "@/lib/client";
import { redirect } from "next/navigation";

// const formSchema = z.object({
//   name: z.string(),
//   boardedOn: z.date(),
//   boardedById: z.date(),
//   country: z.string().optional(),
//   isActive: z.boolean(),
//   billingTypeId: z.string(),
//   lastTouchedBy: z.string(),
// });
const formSchema = z.object({
  name: z.string(),
  startDate: z.date(),
  endDate: z.date().optional(),
  billingPrice: z.number().optional(),
  clientId: z.string(),
});
interface ProjectFormProps extends React.HTMLAttributes<HTMLFormElement> {
  clients?: Client[];
  billingTypes?: BillingType[];
}

export function ProjectForm({
  clients,
  billingTypes,
  className,
  ...props
}: ProjectFormProps) {
  const [isLoading, setIsLoading] = React.useState<boolean>(false);

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      billingPrice: 16,
    },
  });

  async function onSubmit(event: z.infer<typeof formSchema>) {
    setIsLoading(!isLoading);
    console.log(event);

    try {
      var result = await postProject(event as Project);
      if (result) {
        return toast({
          title: "Success.",
          description: "Added project successfully.",
          variant: "default",
        });
      }
    } catch (ex) {
      console.log(ex);
    }
    // Get a Stripe session URL.
    // const response = await fetch("/api/users/stripe");

    // if (!response?.ok) {
    //   return toast({
    //     title: "Something went wrong.",
    //     description: "Please refresh the page and try again.",
    //     variant: "destructive",
    //   });
    // }

    // // Redirect to the Stripe session.
    // // This could be a checkout page for initial upgrade.
    // // Or portal to manage existing subscription.
    // const session = await response.json();
    // if (session) {
    //   window.location.href = session.url;
    // }
  }

  return (
    <Form {...form}>
      <form
        onSubmit={form.handleSubmit(onSubmit)}
        className={cn(className)}
        {...props}
      >
        <FormField
          control={form.control}
          name="name"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Name</FormLabel>
              <FormControl>
                <Input placeholder="Enter project name" {...field} />
              </FormControl>
              <FormDescription>This is project public name.</FormDescription>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="clientId"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Client</FormLabel>
              <Select onValueChange={field.onChange} defaultValue={field.value}>
                <FormControl>
                  <SelectTrigger>
                    <SelectValue placeholder="Select a client" />
                  </SelectTrigger>
                </FormControl>
                <SelectContent>
                  {clients &&
                    clients.length > 0 &&
                    clients?.map((client) => (
                      <SelectItem value={client.id} key={client.id}>
                        {client.name}
                      </SelectItem>
                    ))}
                </SelectContent>
              </Select>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="billingPrice"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Billing Price</FormLabel>
              <FormControl>
                <Input
                  placeholder="Enter average/initial billing price"
                  {...field}
                />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="startDate"
          render={({ field }) => (
            <FormItem className="flex flex-col">
              <FormLabel>Start date</FormLabel>
              <Popover>
                <PopoverTrigger asChild>
                  <FormControl>
                    <Button
                      variant={"outline"}
                      className={cn(
                        "w-[240px] pl-3 text-left font-normal",
                        !field.value && "text-muted-foreground"
                      )}
                    >
                      {field.value ? (
                        format(field.value, "PPP")
                      ) : (
                        <span>Pick a date</span>
                      )}
                      <CalendarIcon className="ml-auto h-4 w-4 opacity-50" />
                    </Button>
                  </FormControl>
                </PopoverTrigger>
                <PopoverContent className="w-auto p-0" align="start">
                  <Calendar
                    mode="single"
                    selected={field.value}
                    onSelect={field.onChange}
                    disabled={(date) =>
                      date > new Date() || date < new Date("1900-01-01")
                    }
                    initialFocus
                  />
                </PopoverContent>
              </Popover>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="endDate"
          render={({ field }) => (
            <FormItem className="flex flex-col">
              <FormLabel>End date</FormLabel>
              <Popover>
                <PopoverTrigger asChild>
                  <FormControl>
                    <Button
                      variant={"outline"}
                      className={cn(
                        "w-[240px] pl-3 text-left font-normal",
                        !field.value && "text-muted-foreground"
                      )}
                    >
                      {field.value ? (
                        format(field.value, "PPP")
                      ) : (
                        <span>Pick a date</span>
                      )}
                      <CalendarIcon className="ml-auto h-4 w-4 opacity-50" />
                    </Button>
                  </FormControl>
                </PopoverTrigger>
                <PopoverContent className="w-auto p-0" align="start">
                  <Calendar
                    mode="single"
                    selected={field.value}
                    onSelect={field.onChange}
                    disabled={(date) =>
                      date > new Date() || date < new Date("1900-01-01")
                    }
                    initialFocus
                  />
                </PopoverContent>
              </Popover>
              <FormMessage />
            </FormItem>
          )}
        />
        <Button type="submit">Submit</Button>
      </form>
    </Form>
  );
}
