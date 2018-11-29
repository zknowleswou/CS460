import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-session-summary',
  templateUrl: './session-summary.component.html',
  styleUrls: ['./session-summary.component.css']
})
export class SessionSummaryComponent implements OnInit {

  workoutSessionId: number;
  constructor(
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.workoutSessionId = +this.route.snapshot.paramMap.get("workoutSessionId");
  }

}
