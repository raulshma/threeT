"use client";

import * as React from "react";

import { BillingType, Client, Project } from "@/types";
import { cn } from "@/lib/utils";
import { Button } from "@/components/ui/button";
import { toast } from "@/components/ui/use-toast";
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
import { ClientFormSchema } from "@/schema";
import { useRouter } from "next/navigation";
import { Checkbox } from "./ui/checkbox";
import { ToastAction } from "./ui/toast";

interface ProjectFormProps extends React.HTMLAttributes<HTMLFormElement> {
  client?: Client;
  billingTypes?: BillingType[];
}

export function ClientForm({
  client,
  billingTypes,
  className,
  ...props
}: ProjectFormProps) {
  const [isLoading, setIsLoading] = React.useState<boolean>(false);
  const router = useRouter();

  const form = useForm<z.infer<typeof ClientFormSchema>>({
    resolver: zodResolver(ClientFormSchema),
    defaultValues: {
      id: client?.id ?? undefined,
      billingTypeId: client?.billingTypeId,
      boardedById: client?.boardedById ?? undefined,
      boardedOn: client?.boardedOn ? new Date(client.boardedOn) : undefined,
      country: client?.country ?? "India",
      isActive: client?.isActive ?? true,
      name: client?.name ?? undefined,
    },
  });

  async function onSubmit(event: z.infer<typeof ClientFormSchema>) {
    setIsLoading(!isLoading);
    console.log(event);

    let submitType = event.id ? "PUT" : "POST";

    try {
      var result = await fetch("/api/clients", {
        method: submitType,
        body: JSON.stringify(event),
      });
      if (result.ok) {
        router.refresh();
        return toast({
          title: "Success.",
          action: (
            <ToastAction
              altText="Goto clients list"
              onClick={() => router.push("/dashboard/clients")}
            >
              Goto clients
            </ToastAction>
          ),
          description: `Client ${
            submitType === "PUT" ? "updated" : "saved"
          } successfully onboarded.`,
          variant: "default",
        });
      } else {
        toast({
          title: "Something went wrong.",
          description: "Client was not created. Please try again.",
          variant: "destructive",
        });
      }
    } catch (ex) {
      console.log(ex);
    }
  }

  return (
    <Form {...form}>
      <form
        onSubmit={form.handleSubmit(onSubmit)}
        className={cn("space-y-3", className)}
        {...props}
      >
        <FormField
          control={form.control}
          name="name"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Name</FormLabel>
              <FormControl>
                <Input placeholder="Enter client name" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="billingTypeId"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Billing type</FormLabel>
              <Select onValueChange={field.onChange} defaultValue={field.value}>
                <FormControl>
                  <SelectTrigger>
                    <SelectValue placeholder="Select billing type" />
                  </SelectTrigger>
                </FormControl>
                <SelectContent>
                  {billingTypes?.map((billingType) => (
                    <SelectItem value={billingType.id} key={billingType.id}>
                      {billingType.name}
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
          name="country"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Country</FormLabel>
              <FormControl>
                <Input placeholder="Enter country name" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="boardedOn"
          render={({ field }) => (
            <FormItem className="flex flex-col">
              <FormLabel>Boarding date</FormLabel>
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
                    // disabled={(date) =>
                    //   date > new Date() || date < new Date("1900-01-01")
                    // }
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
          name="isActive"
          render={({ field }) => (
            <FormItem className="flex flex-row items-start space-x-3 space-y-0 rounded-md border p-4">
              <FormControl>
                <Checkbox
                  checked={field.value}
                  onCheckedChange={field.onChange}
                  title="Is active"
                />
              </FormControl>
              <div className="space-y-1 leading-none">
                <FormLabel>Is active</FormLabel>
              </div>
            </FormItem>
          )}
        />
        <Button type="submit">Submit</Button>
      </form>
    </Form>
  );
}
