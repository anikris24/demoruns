import { Component, Input, ChangeDetectionStrategy,  OnChanges, OnInit, AfterViewInit, AfterViewChecked, SimpleChanges, OnDestroy } from '@angular/core';
import { User } from './user.model';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-on-push-child',
  standalone: true,
  imports: [DatePipe],
  template: `
    <div style="border: 2px solid green; padding: 10px; margin-top: 10px;">
      <h4>🟢 OnPush Child Component</h4>
      <p>Name: <strong>{{ user.name }}</strong></p>
      <p>Age: <strong>{{ user.age }}</strong></p>
      <p>Last Checked: {{ lastChecked | date: 'HH:mm:ss' }}</p>
    </div>
  `,
  // This is the key: only check for changes if inputs change reference or an event fires.
  changeDetection: ChangeDetectionStrategy.OnPush 
})
export class OnPushChildComponent implements OnChanges, OnInit, AfterViewInit, AfterViewChecked, OnDestroy {
  @Input() user!: User;
  lastChecked = new Date();

  ngOnChanges(changes: SimpleChanges) {
    console.log('Child: ngOnChanges fired', changes);
  }

  ngOnInit() {
    console.log('Child: ngOnInit');
  }

  ngAfterViewInit() {
    console.log('Child: ngAfterViewInit');
  }

  ngAfterViewChecked() {
    console.log('Child: ngAfterViewChecked');
  }


  // Lifecycle hook called when Angular checks this component for changes
  ngDoCheck() {
    this.lastChecked = new Date();
    console.log('Child: ngDoCheck ran (OnPush)');
  }

  ngOnDestroy() {
    console.log('Child: ngOnDestroy');
  }
}