import { Component, signal, OnInit, AfterViewInit, AfterViewChecked, OnDestroy, SimpleChanges } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { User } from './user.model';
import { OnPushChildComponent } from './on-push-child-component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, OnPushChildComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit, AfterViewInit, AfterViewChecked, OnDestroy {
  protected readonly title = signal('onpushapp');
  currentUser = new User('Alice', 30);

  ngOnInit() {
    console.log('Parent: ngOnInit');
  }

  ngOnChanges(changes: SimpleChanges) {
    console.log('Parent: ngOnChanges fired', changes);
  }

  ngAfterViewInit() {
    console.log('Parent: ngAfterViewInit');
  }

  ngAfterViewChecked() {
    console.log('Parent: ngAfterViewChecked');
  }

  ngOnDestroy() {
    console.log('Parent: ngOnDestroy');
  }

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

  // 4. Mutates and then creates a new reference to force an update
  mutateAndForceUpdate() {
    this.currentUser.age = 75;
    // By creating a new user object, we change the input reference,
    // which tells the OnPush child component to update.
    this.currentUser = new User(this.currentUser.name, this.currentUser.age);
    console.log('Parent: Mutated and then created new reference. OnPush will update.');
  }

  // 3. Just an event to trigger a global check
  runArbitraryEvent() {
    console.log('Parent: Triggered arbitrary event.');
  }

  noOnDestroy() {
    console.log('Parent: noOnDestroy');
  }
  
  ngDoCheck() {
    console.log('Parent: ngDoCheck ran (Default)');
  }
}
