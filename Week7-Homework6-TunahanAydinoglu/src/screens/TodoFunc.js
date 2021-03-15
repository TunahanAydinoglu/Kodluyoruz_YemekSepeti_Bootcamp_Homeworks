import React, { useState } from "react";
import RemoveButton from "./RemoveButton";
import AddButton from "./AddButton";

const TodoFunc = (props) => {
  const [todo, setTodo] = useState("");
  const [todos, setTodos] = useState([]);

  let addTodo = (todo) => {
    let todosTemp = [];
    todosTemp = [...todos];
    todosTemp.push(todo);
    if(todo !== ''){
      setTodos(todosTemp);
    }
    setTodo("");
  };
  let removeTodo = (index) => {
    let todosTemp = [];
    todosTemp = [...todos];
    todosTemp.splice(index, 1);
    setTodos(todosTemp);
  };

  return (
    <div className="container" style={{marginTop:50}}>
      <div className="card row">
        <div className="card-header">Todo List</div>
        <div className="card-body">
          <input
            className="form-control"
            type="text"
            value={todo}
            placeholder="Enter todo..."
            onChange={(e) => setTodo(e.target.value)}
          />
          <br/>
          <AddButton eklemeFonksiyonu={() => addTodo(todo)} />
          <hr />
        </div>
        <div className="card-body">
          <hr />
          <h5 className="card-title" id="tasks-title">
            Todo List
          </h5>

          <ul className="list-group">
        {todos.map((item, index) => (
          <li key={index} className="list-group-item d-flex justify-content-between">
            {item} <RemoveButton silmeFonksiyonu={()=>removeTodo(index)} />
          </li>
        ))}
      </ul>
          <hr/>
          <button className="btn btn-dark" onClick={()=>setTodos([])}>Clear All Todos</button>
        </div>
      </div>
    </div>
  );
};
export default TodoFunc;
