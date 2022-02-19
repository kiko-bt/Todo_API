import React, { useState, useEffect } from "react";
import axios from "axios";

function DataFetching() {
  const [todos, setTodos] = useState([]);

  useEffect(() => {
    axios
      .get("https://localhost:7244/todo")
      .then((res) => {
        console.log(res);
        setTodos(res.data);
      })
      .catch((err) => {
        console.log(err);
      });
  });

  return (
    <div>
      <ul>
        {todos.map((todo: any) => (
          <li key={todo.id}>{todo.name}</li>
        ))}
      </ul>
    </div>
  );
}

export default DataFetching;
