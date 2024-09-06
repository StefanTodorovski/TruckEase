import { Transport} from "../enums/transportType";

export class CreateTransportRequest {
    public Description!: string;
    public StartTime!: Date;
    public ArrivalTime!: Date;
    public StartLocation!: string;
    public Destination!: string;
    public IsExpress!: boolean;
    public Price!: DoubleRange;
    public LoadWeight!: DoubleRange;
    public IsDraft!: boolean;
    public TransportType!: Transport;
  }