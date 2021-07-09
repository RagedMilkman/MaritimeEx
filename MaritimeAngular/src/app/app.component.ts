import { Component } from '@angular/core';
import { RESTService } from './rest.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
    title = 'MaritimeAngular';

    public AllData : string;

    public Mean : string;
    public StandardDeviation : string;
    public BinFrequencies : string;

    /**
     *
     */
    constructor(private REST : RESTService) {
        this.AllData = "unretrieved"
        this.Mean = "uncalculated";
        this.StandardDeviation = "uncalculated";
        this.BinFrequencies = "uncalculated";
    }

    public EnterValuesIntoDB() : void {
        this.REST.Get("EnterValuesIntoDB").subscribe(data => {
            console.log("Saved Values!", data);
        },
        (error) => {
            console.log("Not Saved Values!")
        });
    }

    public GetData() : void {
        this.REST.Get("GetValues").subscribe((data : any[]) => {
            console.log("Got Data!", data.map(x => x.value))
            this.AllData = data.map(x => x.value).toString();
        },
        (error) => {
            console.log("Not Got Data!")
        });
    }

    public CalculateArithmeticMean() : void {
        this.REST.Get("CalculateArithmeticMean").subscribe(data => {
            console.log("Got Mean!", data)
            this.Mean = data;
        },
        (error) => {
            console.log("Not Got Data!")
        });
    }

    public CalculateStandardDeviation() : void {
        this.REST.Get("CalculateStandardDeviation").subscribe(data => {
            console.log("Got Standard Deviation!", data)
            this.StandardDeviation = data;
        },
        (error) => {
            console.log("Not Got Data!")
        });
    }

    public ComputeFrequenciesOfBinSize10() : void {
        this.REST.Get("ComputeFrequenciesOfBinSize10").subscribe(data => {
            console.log("Got Bins of 10!", data)
            this.BinFrequencies = data;
        },
        (error) => {
            console.log("Not Got Data!")
        });
    }

}
