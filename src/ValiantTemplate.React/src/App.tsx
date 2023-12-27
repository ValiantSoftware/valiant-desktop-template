import { useEffect, useState } from "react";
import { Button } from "./components/Button";
import Header from "./components/Header";
import React from "react";

function App() {
  const [count, setCount] = useState(0);
  const [randomNumber, setRandomNumber] = useState("");

  const getRandomNumberFromApi = async () => {
    const response = await fetch("/api/rng");
    const value = await response.text();
    return value;
  };

  const launchCalculator = async () => {
    await fetch("/api/calc", { method: "POST" });
  };

  useEffect(() => {
    async function fetch() {
      const guid = await getRandomNumberFromApi();
      setRandomNumber(guid);
    }
    fetch();
  }, []);

  return (
    <>
      <div className="flex h-screen flex-col justify-between">
        <Header
          title="Valiant Template"
          body="A desktop app template using Photino for the desktop app shell, React for the UI, and .NET Core for the backend. Lightweight, fast, and supporting native compilation."
        />
        <div className="mx-auto flex max-w-xl flex-col gap-2 md:gap-4 h-full">
          <Button className="w-full" onClick={() => setCount((count) => count + 1)}>
            Count (React): {count}
          </Button>
          <Button className="w-full" onClick={async () => setRandomNumber(await getRandomNumberFromApi())}>
            Random number (.NET): {randomNumber}
          </Button>
          <Button className="w-full" onClick={launchCalculator}>
            Launch Windows Calculator
          </Button>
        </div>
        <footer className="mx-auto p-10 text-gray-400">
          <span className="mx-2">Useful links:</span>
          <a className="text-indigo-400 hover:underline" href="https://www.tryphotino.io/" target="_blank">
            Photino
          </a>
          <span className="mx-2">/</span>
          <a className="text-indigo-400 hover:underline" href="https://react.dev/" target="_blank">
            React
          </a>
          <span className="mx-2">/</span>
          <a className="text-indigo-400 hover:underline" href="https://asp.net/" target="_blank">
            ASP.NET
          </a>
          <span className="mx-2">/</span>
          <a className="text-indigo-400 hover:underline" href="https://valiantsoftware.com.au/" target="_blank">
            Valiant
          </a>
        </footer>
      </div>
    </>
  );
}

export default App;
