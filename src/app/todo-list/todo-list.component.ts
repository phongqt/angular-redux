import { Component, OnInit } from '@angular/core';
import { NgRedux, select } from '@angular-redux/store';
import { NgForm } from '@angular/forms';

import { ITodo } from '../todo';
import { ADD_TODO, TOGGLE_TODO, REMOVE_TODO, REMOVE_ALL_TODO, LIST_TODO } from '../actions/types';
import { IAppState } from '../store';
import { TodoActions } from '../actions/todo';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent implements OnInit {
  @select() todos;
  model: ITodo = {
    id: 0,
    description: '',
    responsible: '',
    priority: 'low',
    isComplete: false
  };
  constructor(private ngRedux: NgRedux<IAppState>, private todoActions: TodoActions) { }

  ngOnInit() {
    this.todoActions.list();
  }

  onSubmit(form: NgForm) {
    this.ngRedux.dispatch({ type: ADD_TODO, todo: this.model });
    form.resetForm(this.model = {
      id: 0,
      description: '',
      responsible: '',
      priority: 'low',
      isComplete: false
    });

  }

  toggleTodo(todo) {
    this.ngRedux.dispatch({ type: TOGGLE_TODO, id: todo.id });
  }

  removeTodo(todo) {
    this.ngRedux.dispatch({ type: REMOVE_TODO, id: todo.id });
  }
}
