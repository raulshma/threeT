"use client";
import { cn } from "@/lib/utils";
import {
  Popover,
  PopoverTrigger,
  PopoverContent,
} from "@/components/ui/popover";
import {
  CommandInput,
  CommandEmpty,
  CommandGroup,
  CommandItem,
  CommandList,
  CommandSeparator,
  CommandShortcut,
  Command,
} from "@/components/ui/command";
import {
  ChevronsUpDown,
  Check,
  Calculator,
  Calendar,
  CreditCard,
  Settings,
  Smile,
  User,
} from "lucide-react";
import React from "react";
import { Button } from "@/components/ui/button";
import { Member, ProjectUser } from "@/types";

type ProjectMembersComboBoxProps = {
  items: Member[];
  existingMembers: ProjectUser[];
};

export function ProjectMembersComboBox({
  items,
  existingMembers,
}: ProjectMembersComboBoxProps) {
  const [open, setOpen] = React.useState(false);
  const [value, setValue] = React.useState("");

  if (!items || items?.length <= 0) return null;

  let data: Member[] = [];
  if (existingMembers && existingMembers.length > 0)
    data = items.filter(
      (e) => !existingMembers.some((em) => em.userEmail === e.email)
    );
  return (
    <>
      <Popover open={open} onOpenChange={setOpen}>
        <PopoverTrigger>
          <Button
            variant="outline"
            role="combobox"
            aria-expanded={open}
            className="w-[400px] justify-between"
          >
            {value
              ? data.find((member) => member.userName.startsWith(value))?.email
              : "Select member..."}
            <ChevronsUpDown className="ml-2 h-4 w-4 shrink-0 opacity-50" />
          </Button>
        </PopoverTrigger>
        <PopoverContent className="w-[400px] p-1">
          <Command>
            <CommandInput placeholder="Search members..." />
            <CommandEmpty>No member found.</CommandEmpty>
            <CommandGroup>
              {data.map((member) => (
                <CommandItem
                  key={member.id}
                  onSelect={(currentValue: string) => {
                    setValue(currentValue === value ? "" : currentValue);
                    setOpen(false);
                  }}
                >
                  <Check
                    className={cn(
                      "mr-2 h-4 w-4",
                      value === member.userName ? "opacity-100" : "opacity-0"
                    )}
                  />
                  {member.email}
                </CommandItem>
              ))}
            </CommandGroup>
          </Command>
        </PopoverContent>
      </Popover>
    </>
  );
}
