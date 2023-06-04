import { AvatarProps } from "@radix-ui/react-avatar";

import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import { Icons } from "@/components/icons";

interface UserAvatarProps extends AvatarProps {
  image?: string;
  name?: string;
}

export function UserAvatar({ image, name, ...props }: UserAvatarProps) {
  return (
    <Avatar {...props}>
      {image ? (
        <AvatarImage alt="Picture" src={image} />
      ) : (
        <AvatarFallback>
          <span className="sr-only">{name}</span>
          <Icons.user className="h-4 w-4" />
        </AvatarFallback>
      )}
    </Avatar>
  );
}
