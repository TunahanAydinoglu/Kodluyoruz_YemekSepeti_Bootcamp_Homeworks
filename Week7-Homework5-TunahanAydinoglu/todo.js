const form = document.getElementById("todo-form");
const todoInput = document.getElementById("todo");
const todoList = document.querySelector(".list-group");
const firstCardBody = document.querySelectorAll(".card-body")[0];
const secondCardBody = document.querySelectorAll(".card-body")[1];
const filter = document.querySelector("#filter");
const clearButton = document.querySelector("#clear-todos");

form.addEventListener("submit", (e)=>addTodo(e));
document.addEventListener("DOMContentLoaded", (e)=>loadAllTodosToUI());
secondCardBody.addEventListener("click", (e)=>deleteTodo(e));
filter.addEventListener("keyup", (e)=>filterTodos(e));
clearButton.addEventListener("click", (e)=>clearAllTodos(e));

let clearAllTodos = (e) => {
  if (confirm("Tümünü silmek istediğinize emin misiniz ?")) {
    while (todoList.firstElementChild != null) {
      todoList.removeChild(todoList.firstElementChild);
    }
    localStorage.removeItem("todos");
  }
};
let filterTodos = (e) => {
  const filterValue = e.target.value.toLowerCase();
  const listItems = document.querySelectorAll(".list-group-item");
  listItems.forEach(function (listItem) {
    const text = listItem.textContent.toLowerCase();
    if (text.indexOf(filterValue) === -1) {
      listItem.setAttribute("style", "display : none !important");
    } else {
      listItem.setAttribute("style", "display : block");
    }
  });
};
let deleteTodoFromStorage = (deleteTodo) => {
  let todos = getTodosFromStorage();
  todos.forEach(function (todo, index) {
    if (todo === deleteTodo) {
      todos.splice(index, 1);
    }
  });
  localStorage.setItem("todos", JSON.stringify(todos));
};
let deleteTodo = (e) => {
  if (e.target.className === "fa fa-remove") {
    let todo = e.target.parentElement.parentElement;
    todo.remove();
    deleteTodoFromStorage(todo.textContent);
  }
};
let loadAllTodosToUI = () => {
  let todos = getTodosFromStorage();
  console.log(todos)
  if (todos.length == 0) {
    todos = ["Daha Guzel Tasarim", "Todolar calisir hale gelecek"];
  }
  todos.forEach(function (todo) {
    addTodoToUI(todo);
  });
};
let addTodo = (e) => {
  const newTodo = todoInput.value.trim();
  if (newTodo === "") {
    alert("Lütfen Bir Todo Girin");
  } else {
    addTodoToUI(newTodo);
    addTodoToStorage(newTodo);
  }
  e.preventDefault();
};
let getTodosFromStorage = () => {
  let todos;
  if (localStorage.getItem("todos") === null) {
    todos = [];
  } else {
    todos = JSON.parse(localStorage.getItem("todos"));
  }
  return todos;
};
let addTodoToStorage = (newTodo) => {
  let todos = getTodosFromStorage();
  todos.push(newTodo);
  localStorage.setItem("todos", JSON.stringify(todos));
};
let addTodoToUI = (newTodo) => {
  const listItem = document.createElement("li");
  const link = document.createElement("a");
  link.href = "#";
  link.className = "delete-item";
  link.innerHTML = "<i class = 'fa fa-remove'></i>";
  listItem.className = "list-group-item d-flex justify-content-between";
  listItem.appendChild(document.createTextNode(newTodo));
  listItem.appendChild(link);
  todoList.appendChild(listItem);
  todoInput.value = "";
};
