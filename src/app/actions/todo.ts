import { Injectable } from '@angular/core';
import { NgRedux } from '@angular-redux/store';

import { IAppState } from '../store';
import { ADD_TODO, TOGGLE_TODO, REMOVE_TODO, REMOVE_ALL_TODO, LIST_TODO } from './types';

@Injectable()
export class TodoActions {
  constructor(private ngRedux: NgRedux<IAppState>) { }

  list = async () => {
    this.ngRedux.dispatch({ type: LIST_TODO });
  }

  add = async () => {
    this.ngRedux.dispatch({ type: ADD_TODO });
  }

  delete = async () => {
    this.ngRedux.dispatch({ type: REMOVE_TODO });
  }
}
