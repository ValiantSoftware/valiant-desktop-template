import React from "react";
import { clsx } from "clsx";
import { MouseEventHandler } from "react";
import { ReactNode } from "react";

export interface ButtonProps {
  onClick: MouseEventHandler<HTMLButtonElement> | undefined;
  children: ReactNode;
  className?: string;
}

export function Button(props: ButtonProps) {
  return (
    <button
      type="button"
      onClick={props.onClick}
      className={clsx(
        props.className,
        "text-md rounded-md bg-indigo-600 px-6 py-2 font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
      )}>
      {props.children}
    </button>
  );
}
