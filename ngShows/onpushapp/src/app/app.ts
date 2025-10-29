import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { User } from './user.model';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('onpushapp');
  currentUser = new User('Alice', 30);
  
  // 1. Correctly updates the child component
  changeUserReference() {
    // A new object reference is created, which triggers OnPush
    this.currentUser = new User('Bob', 25); 
    console.log('Parent: Changed user reference. OnPush will update.');
  }

  // 2. Does NOT update the child component 
  mutateUserProperty() {
    // Only the internal property is changed; the object reference is the same.
    this.currentUser.age = 50; 
    console.log('Parent: Mutated user property. OnPush will NOT update.');
    
    // NOTE: The parent component's ngDoCheck still runs, but the child is skipped.
  }

  // 3. Just an event to trigger a global check
  runArbitraryEvent() {
    console.log('Parent: Triggered arbitrary event.');
  }
  
  ngDoCheck() {
    console.log('Parent: ngDoCheck ran (Default)');
  }
}
