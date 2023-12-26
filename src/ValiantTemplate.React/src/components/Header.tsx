import React from "react";

export interface HeaderProps {
  title: string;
  body: string;
}

export default function Header(props: HeaderProps) {
  return (
    <div className="bg-white px-6 py-24 lg:px-8">
      <div className="mx-auto max-w-2xl text-center">
        <h2 className="text-4xl font-bold tracking-tight text-gray-900 sm:text-6xl">{props.title}</h2>
        <p className="mt-6 text-lg leading-8 text-gray-600">{props.body}</p>
      </div>
    </div>
  );
}
